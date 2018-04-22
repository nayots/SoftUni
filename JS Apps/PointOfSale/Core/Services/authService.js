/** @description Handles authentication
 */
const AuthService = (() => {
    /** @description Saves the user information to session storage
     * @param {object} userInfo The userInfo object.
     */
    function saveSession(userInfo) {
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authtoken', userAuth);
        let userId = userInfo._id;
        sessionStorage.setItem('userId', userId);
        let username = userInfo.username;
        sessionStorage.setItem('username', username);
    }

    /** @description Determinates if the current user is authenticated
     * @returns {boolean} True or False
     */
    function isAuth() {
        return sessionStorage.getItem("authtoken") !== null;
    }

    /** @description Creates login request Promise
     * @param {string} username The username.   
     * @param {string} password The password.
     * @return {Promise}  Promise object.
     */
    function login(username, password) {
        let userData = {
            username,
            password
        };

        return RequestService.post('user', 'login', 'basic', userData);
    }

    /** @description Creates register request Promise
     * @param {string} username The username.   
     * @param {string} password The password.
     * @param {string} repeatPassword The password repeated (not used in the request).
     * @return {Promise}  Promise object.
     */
    function register(username, password, repeatPassword) {
        let userData = {
            username,
            password
        };

        return RequestService.post('user', '', 'basic', userData);
    }

    /** @description Creates logout request Promise
     * @param {string} username The username.   
     * @param {string} password The password.
     * @return {Promise}  Promise object.
     */
    function logout() {
        let logoutData = {
            authtoken: sessionStorage.getItem('authtoken')
        };

        return RequestService.post('user', '_logout', 'kinvey', logoutData);
    }

    return {
        login,
        register,
        logout,
        saveSession,
        isAuth
    }
})()