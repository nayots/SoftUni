import { PasswordValidation } from "./../../../customValidation/passwordValidation";
import { RegisterModel } from "./../../../models/registerModel";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthenticationService } from "../../authentication/authentication.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-register-form",
  templateUrl: "./register-form.component.html",
  styleUrls: ["./register-form.component.css"]
})
export class RegisterFormComponent implements OnInit {
  private registerFormModel: RegisterModel;
  private registerForm: FormGroup;
  private errorMessage: string;

  constructor(
    private fb: FormBuilder,
    private auth: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit() {
    this.registerForm = this.fb.group(
      {
        username: ["", [Validators.pattern("^[A-Z][A-Za-z0-9]+$")]],
        password: ["", [Validators.pattern("^[A-Za-z0-9]{4,16}$")]],
        confirmPassword: ["", [Validators.required]],
        firstName: ["", [Validators.pattern("^[A-Z][A-Za-z]+$")]],
        lastName: ["", [Validators.pattern("^[A-Z][A-Za-z]+$")]],
        email: ["", [Validators.pattern(/^.+@.+\..+$/)]],
        age: [null]
      },
      {
        validator: PasswordValidation.MatchPassword
      }
    );
  }

  onSubmit() {
    console.log(this.registerForm);
    this.registerFormModel = new RegisterModel(
      this.username.value,
      this.password.value,
      this.firstName.value,
      this.lastName.value,
      this.email.value,
      this.age.value
    );
    this.auth.register(this.registerFormModel).subscribe(
      data => {
        this.successfulRegister(data);
      },
      error => {
        console.log(error);
        this.errorMessage = error.description || error.message;
      }
    );
  }

  private successfulRegister(data) {
    this.auth.authtoken = data["_kmd"]["authtoken"];
    localStorage.setItem("authtoken", data["_kmd"]["authtoken"]);
    localStorage.setItem("username", data["username"]);
    this.router.navigate(["/"]);
  }

  get username() {
    return this.registerForm.get("username");
  }

  get password() {
    return this.registerForm.get("password");
  }

  get confirmPassword() {
    return this.registerForm.get("confirmPassword");
  }

  get firstName() {
    return this.registerForm.get("firstName");
  }

  get lastName() {
    return this.registerForm.get("lastName");
  }

  get email() {
    return this.registerForm.get("email");
  }

  get age() {
    return this.registerForm.get("age");
  }
}
