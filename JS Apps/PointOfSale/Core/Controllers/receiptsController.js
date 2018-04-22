const ReceiptsController = (() => {

    function editor(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        ctx.isAuth = isAuth;
        ctx.cashier = sessionStorage.getItem("username");
        let activeReceiptId = sessionStorage.getItem("activeReceiptId");        
        if (!activeReceiptId) {
            ReceiptService.createReceipt(0,0).then((res) => {                
                sessionStorage.setItem("activeReceiptId", res._id);
                sessionStorage.setItem("activeReceiptTotal", res.total);
                sessionStorage.setItem("activeReceiptProductCount", res.productCount);
                ctx.redirect("#/home");
                return;
            }).catch(RequestService.handleError);
        }

        ReceiptService.getActiveReceipt().then((res) => {

            sessionStorage.setItem("activeReceiptId", res[0]._id);
            activeReceiptId = sessionStorage.getItem("activeReceiptId");
            sessionStorage.setItem("activeReceiptTotal", res[0].total);
            sessionStorage.setItem("activeReceiptProductCount", res[0].productCount);

            ReceiptService.getEntriesByReceiptId(activeReceiptId).then((entrs) => {                
                let entries = entrs;
                for (const entry of entries) {
                    entry.total = Number(entry.qty) * Number(entry.price);
                }
                ctx.entries = entries;
                ctx.receiptTotal = Number(sessionStorage.getItem("activeReceiptTotal"));
                
                ctx.loadPartials({
                    header: "Core/Views/Shared/header.hbs",
                    navigation: "Core/Views/Shared/navigation.hbs",
                    footer: "Core/Views/Shared/footer.hbs"
                }).then(function (context) {            
                    this.partial("Core/Views/Receipts/create.hbs");
                })
            })

        }).catch(RequestService.handleError);
    }

    function addEntry(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        ctx.isAuth = isAuth;
        ctx.cashier = sessionStorage.getItem("username");
        
        let type = ctx.params.type;
        let qty = ctx.params.qty;
        let price = ctx.params.price;

        if (type && qty && price && !isNaN(qty) && !isNaN(price) && Number(qty) > 0 && Number(price) > 0) {
            let receiptId = sessionStorage.getItem("activeReceiptId");
            ReceiptService.addEntry(type, Number(qty), Number(price), receiptId).then((res) => {
                ReceiptService.getActiveReceipt().then((actRec) => {
                    let currentlyActiveRec = actRec[0];
                    currentlyActiveRec.productCount = Number(currentlyActiveRec.productCount) + 1;
                    currentlyActiveRec.total = Number(currentlyActiveRec.total) + (Number(qty) * Number(price));
                    ReceiptService.commitReceipt(currentlyActiveRec._id, currentlyActiveRec).then(() => {
                        ctx.redirect("#/home");
                        NotificationService.showInfo("Entry added");
                    });
                })
            }).catch(RequestService.handleError);
        } else {
            NotificationService.showError("Name can't be empty and Quantity and price must be valid numbers above 0!");
            return;
        }
    }

    function deleteEntry(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        let entryId = ctx.params.id;
        let entry = ReceiptService.getEntry(entryId).then((entr) => {

            ReceiptService.getActiveReceipt().then((actRec) => {
                let currentlyActiveRec = actRec[0];
                currentlyActiveRec.productCount = Number(currentlyActiveRec.productCount) - 1;
                currentlyActiveRec.total = Number(currentlyActiveRec.total) - (Number(entr.qty) * Number(entr.price));
                ReceiptService.commitReceipt(currentlyActiveRec._id, currentlyActiveRec).then(() => {
                    ReceiptService.deleteEntry(entryId).then(() => {
                        ctx.redirect("#/home");
                        NotificationService.showInfo("Entry removed");
                    });
                });
            })
        }).catch(RequestService.handleError);   
    }

    function checkOut(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        let totalProductsCount = sessionStorage.getItem("activeReceiptProductCount");

        if (totalProductsCount && Number(totalProductsCount) > 0) {
            ReceiptService.getActiveReceipt().then((actRec) => {
                let currentlyActiveRec = actRec[0];
                currentlyActiveRec.active = false;
                ReceiptService.commitReceipt(currentlyActiveRec._id, currentlyActiveRec).then(() => {
                    sessionStorage.removeItem("activeReceiptId");
                    sessionStorage.removeItem("activeReceiptTotal");
                    sessionStorage.removeItem("activeReceiptProductCount");
                    ctx.redirect("#/home");
                    NotificationService.showInfo("Receipt checked out");
                }).catch(RequestService.handleError);
            })
        } else {
            ctx.redirect("#/home");
            NotificationService.showError("You cannot checkout an empty receipt!");
        }
    }

    function overview(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        ctx.isAuth = isAuth;
        ctx.cashier = sessionStorage.getItem("username");
        ReceiptService.getUserReceipts().then((rec) => {
            rec = rec.reverse();
            for (const r of rec) {
                let creationDate = new Date( Date.parse(r._kmd.ect));               
                r.created = `${creationDate.getFullYear()}-${creationDate.getMonth()+1}-${creationDate.getDate()} ${creationDate.getHours()}:${creationDate.getMinutes()}`;
            }
            ctx.receipts = rec;
            ctx.loadPartials({
                header: "Core/Views/Shared/header.hbs",
                navigation: "Core/Views/Shared/navigation.hbs",
                footer: "Core/Views/Shared/footer.hbs"
            }).then(function (context) {            
                this.partial("Core/Views/Receipts/list.hbs");
            })
        })
    }

    function details(ctx) {
        let isAuth = AuthService.isAuth();
        if (!isAuth) {
            ctx.redirect("#/home");
            return;
        }
        ctx.isAuth = isAuth;
        ctx.cashier = sessionStorage.getItem("username");

        let id = ctx.params.id;
        if (id) {
        ReceiptService.getEntriesByReceiptId(id).then((entries) => {
            for (const ent of entries) {
                ent.total = Number(ent.qty) * Number(ent.price);
            }

            ctx.entries = entries;
            ctx.loadPartials({
                header: "Core/Views/Shared/header.hbs",
                navigation: "Core/Views/Shared/navigation.hbs",
                footer: "Core/Views/Shared/footer.hbs"
            }).then(function (context) {            
                this.partial("Core/Views/Receipts/details.hbs");
            })
        }).catch(RequestService.handleError);
            
        } else {
            ctx.redirect("#/receipts/overview");
        }

    }

    return {
        editor,
        addEntry,
        deleteEntry,
        checkOut,
        overview,
        details
    }
})();