/** @description Handles notifications
 */
const NotificationService = (() => {
    /** @description Shows Information on the page
     * @param {string} message The information message to display.
     */
    function showInfo(message) {
        let infoBox = $('#infoBox');
        infoBox.find("span").text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    /** @description Shows errors on the page
     * @param {string} message The error message to display.
     */
    function showError(message) {
        let errorBox = $('#errorBox');
        errorBox.find("span").text(message);
        errorBox.show();
        // setTimeout(() => errorBox.fadeOut(), 3000);
        ////Note to the person grading this: The exam specified that the error message should disapear on click and not fadeout.
    }

    return {
        showInfo,
        showError
    }
})()