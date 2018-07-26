export default class TsRequest {
    method: string;
    uri: string;
    version: string;
    message: string;
    response: string | undefined = undefined;
    fulfilled: boolean = false;
    constructor(method: string, uri: string, version : string , message: string){
        this.method = method;
        this.uri= uri;
        this.version = version;
        this.message = message;
    }
}
