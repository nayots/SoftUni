function validateRequest(request) {
    const METHODS = ["GET", "POST", "DELETE", "CONNECT"];
    const URI_REGEX = /^[\w.]+$/;
    const VERSIONS = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    const MESSAGE_REGEX = /^[^<>\\&'"]*$/g;
    let objectKeys = Object.keys(request);
    if (!objectKeys.includes("method") || !METHODS.includes(request.method)) {
        throwError("Method");
    }
    if (!objectKeys.includes("uri") || !URI_REGEX.test(request.uri)) {
        throwError("URI");
    }
    if (!objectKeys.includes("version") || !VERSIONS.includes(request.version)) {
        throwError("Version");
    }
    if (!objectKeys.includes("message") || !MESSAGE_REGEX.test(request.message)) {
        throwError("Message");
    }

    return request;

    function throwError(invalidHeader) {
        throw new Error(`Invalid request header: Invalid ${invalidHeader}`);
    }
}