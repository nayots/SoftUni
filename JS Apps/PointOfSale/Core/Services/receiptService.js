const ReceiptService = (() => {
    function getActiveReceipt() {
        let userId = sessionStorage.getItem('userId');
        return RequestService.get('appdata', `receipts?query={"_acl.creator":"${userId}","active": "true"}`, 'kinvey');
    }

    function getEntriesByReceiptId(receiptId) {
        return RequestService.get("appdata", `entries?query={"receiptId":"${receiptId}"}`, "kinvey")
    }

    function createReceipt(productCount, total) {
        let data = {
            active : true,
            productCount : productCount,
            total: total
        };

        return RequestService.post("appdata", "receipts", "kinvey", data);
    }

    function getUserReceipts() {
        let userId = sessionStorage.getItem('userId');

        return RequestService.get("appdata", `receipts?query={"_acl.creator":"${userId}","active": "false"}`, "kinvey");
    }

    function getReceiptDetails(receiptId) {
        return RequestService.get("appdata", `receipts/${receiptId}`, "kinvey");        
    }

    function commitReceipt(receiptId, data) {
        return RequestService.update("appdata", `receipts/${receiptId}`, "kinvey", data);
    }

    function addEntry(type, qty, price, receiptId) {
        let data = {
            type,
            qty,
            price,
            receiptId
        };

        return RequestService.post("appdata", "entries", "kinvey", data);
    }

    function getEntry(entryId) {
        return RequestService.get("appdata", `entries/${entryId}`, "kinvey");
    }

    function deleteEntry(entryId) {
        return RequestService.remove("appdata", `entries/${entryId}`, "kinvey");
    }

    return {
        getActiveReceipt,
        getEntriesByReceiptId,
        createReceipt,
        getUserReceipts,
        getReceiptDetails,
        commitReceipt,
        addEntry,
        getEntry,
        deleteEntry
    }
})()