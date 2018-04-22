$(() => {
    $(document).on({
        ajaxStart: function () {
            $("#loadingBox").show()
        },
        ajaxStop: function () {
            $("#loadingBox").hide()
        }
    })

    $('#errorBox').on("click", function () {
        $(this).hide();
    })
    $('#infoBox').on("click", function () {
        $(this).hide();
    })

    //No idea why this is not working so i will comment it out. =/
    // $("#create-entry-form :input[type!=submit]").on("change", () => 
    // { 
    //     let fields = $("#create-entry-form :input[type!=submit]")
    //     let type = $(fields[0]).val();
    //     let qty = $(fields[1]).val();
    //     let price = $(fields[2]).val();

    //     if (qty && price && !isNaN(qty) && !isNaN(price) && Number(qty) > 0 && Number(price)) {
    //         let totalPrice = Number(qty) * Number(price);
    //         console.log(totalPrice);
            
    //         $($("#create-entry-form div")[3]).text(`Sub-total ${totalPrice}`);
    //     }        
    // });

    const app = Sammy('#container', function () {
        this.use("Handlebars", "hbs");

        this.get("/", HomeController.landing);
        this.get("index.html", HomeController.landing);
        this.get("#/home", HomeController.landing);

        this.post("#/register", UserController.registerPost);
        this.post("#/login", UserController.loginPost);
        this.get("#/logout", UserController.logout);

        this.get("#/receipts/editor", ReceiptsController.editor);
        this.post("#/entries/add", ReceiptsController.addEntry);
        this.get("#/entries/delete/:id", ReceiptsController.deleteEntry);
        this.post("#/receipt/checkout", ReceiptsController.checkOut);

        this.get("#/receipts/overview", ReceiptsController.overview);
        this.get("#/receipts/details/:id", ReceiptsController.details);
    });

    app.run();
});