import { LoginModel } from "./../../models/loginModel";
import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { RegisterModel } from "../../models/registerModel";

const appKey = "kid_Hyp6n_yHm";
const appSecret = "7b61811eafee425baece3b799b11f8aa";
const registerUrl = `https://baas.kinvey.com/user/${appKey}`;
const loginUrl = `https://baas.kinvey.com/user/${appKey}/login`;
const logoutUrl = `https://baas.kinvey.com/user/${appKey}/_logout`;

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  private currentAuthtoken = "";
  constructor(private http: HttpClient) {}

  public login(loginModel: LoginModel) {
    return this.http.post(loginUrl, JSON.stringify(loginModel), {
      headers: this.createAuthHeaders("Basic")
    });
  }

  public register(registerModel: RegisterModel) {
    return this.http.post(registerUrl, JSON.stringify(registerModel), {
      headers: this.createAuthHeaders("Basic")
    });
  }

  public logout() {
    return this.http.post(
      logoutUrl,
      {},
      {
        headers: this.createAuthHeaders("Kinvey")
      }
    );
  }

  private createAuthHeaders(type: string): HttpHeaders {
    if (type === "Basic") {
      return new HttpHeaders({
        Authorization: `Basic ${btoa(`${appKey}:${appSecret}`)}`,
        "Content-Type": "application/json"
      });
    } else {
      return new HttpHeaders({
        Authorization: `Kinvey ${localStorage.getItem("authtoken")}`,
        "Content-Type": "application/json"
      });
    }
  }

  public checkIfLoggedIn() {
    return this.currentAuthtoken === localStorage.getItem("authtoken");
  }

  get authtoken() {
    return this.currentAuthtoken;
  }

  set authtoken(value: string) {
    this.currentAuthtoken = value;
  }
}
