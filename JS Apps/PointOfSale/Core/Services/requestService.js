/** @description Handles requests
 */
const RequestService = (() => {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_HJfegCx3M";
    const kinveyAppSecret = "6cfde2c542914f95abe9514e22c4fc94";

    /** @description Creates the authentication header
     * @param {string} type The name of the auth header type
     * @return {string}  
     */
    function makeAuth(type) {
        return type === 'basic' ?
            'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret) :
            'Kinvey ' + sessionStorage.getItem('authtoken');
    }

    /** @description Creates request object to kinvey
     * @param {string} method The method type: GET POST PUT DELETE.   
     * @param {string} module The name of the module.   
     * @param {string} endpoint The name of the endpoint.  
     * @param {string} auth The type of auth, can be Kinvey or Basic.
     * @return {Promise}  Promise object.
     */
    function makeRequest(method, module, endpoint, auth) {
        return req = {
            method,
            url: kinveyBaseUrl + module + '/' + kinveyAppKey + '/' + endpoint,
            headers: {
                'Authorization': makeAuth(auth)
            }
        };
    }

    /** @description Function to return GET promise
     * @param {string} module The name of the module, can be appdata or user.  
     * @param {string} endpoint The name of the endpoint.  
     * @param {string} auth The type of auth, can be Kinvey or Basic.
     * @return {Promise}  Promise object. 
     */
    function get(module, endpoint, auth) {
        return $.ajax(makeRequest('GET', module, endpoint, auth));
    }

    /** @description Function to return POST promise
     * @param {string} module The name of the module, can be appdata or user.  
     * @param {string} endpoint The name of the endpoint.  
     * @param {string} auth The type of auth, can be Kinvey or Basic.  
     * @param {object} data The data object for the request.  
     * @return {Promise}  Promise object.
     */
    function post(module, endpoint, auth, data) {
        let req = makeRequest('POST', module, endpoint, auth);
        req.data = data;
        return $.ajax(req);
    }

    /** @description Function to return PUT promise
     * @param {string} module The name of the module, can be appdata or user.  
     * @param {string} endpoint The name of the endpoint.  
     * @param {string} auth The type of auth, can be Kinvey or Basic.  
     * @param {object} data The data object for the request.  
     * @return {Promise}  Promise object.
     */
    function update(module, endpoint, auth, data) {
        let req = makeRequest('PUT', module, endpoint, auth);
        req.data = data;
        return $.ajax(req);
    }

    /** @description Function to return DELETE promise 
     * @param {string} module The name of the module, can be appdata or user.  
     * @param {string} endpoint The name of the endpoint.  
     * @param {string} auth The type of auth, can be Kinvey or Basic.  
     * @return {Promise}  Promise object.
     */
    function remove(module, endpoint, auth) {
        return $.ajax(makeRequest('DELETE', module, endpoint, auth));
    }

    /** @description Function to handle Promise error 
     * @param {any} reason promise error responce.
     */
    function handleError(reason) {
        NotificationService.showError(reason.responseJSON.description);
    }

    return {
        get,
        post,
        update,
        remove,
        handleError
    }
})()