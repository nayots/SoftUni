import { Router } from "@angular/router";
import { AuthenticationService } from "./../../authentication/authentication.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { LoginModel } from "./../../../models/loginModel";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-login-form",
  templateUrl: "./login-form.component.html",
  styleUrls: ["./login-form.component.css"]
})
export class LoginFormComponent implements OnInit {
  private loginFormModel: LoginModel;
  private loginForm: FormGroup;
  private errorMessage: string;

  constructor(
    private fb: FormBuilder,
    private auth: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      username: ["", [Validators.pattern("^[A-Z][A-Za-z0-9]+$")]],
      password: ["", [Validators.pattern("^[A-Za-z0-9]{4,16}$")]]
    });
  }

  onSubmit() {
    console.log(this.loginForm);
    this.loginFormModel = new LoginModel(
      this.username.value,
      this.password.value
    );
    this.auth.login(this.loginFormModel).subscribe(
      data => {
        this.successfulLogin(data);
      },
      error => {
        console.log(error);
        this.errorMessage = error.description || error.message;
      }
    );
  }

  private successfulLogin(data) {
    this.auth.authtoken = data["_kmd"]["authtoken"];
    localStorage.setItem("authtoken", data["_kmd"]["authtoken"]);
    localStorage.setItem("username", data["username"]);
    this.router.navigate(["/"]);
  }

  get username() {
    return this.loginForm.get("username");
  }

  get password() {
    return this.loginForm.get("password");
  }
}
