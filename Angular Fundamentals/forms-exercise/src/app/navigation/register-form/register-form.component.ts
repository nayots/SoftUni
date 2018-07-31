import { PasswordValidation } from "./../../../customValidation/passwordValidation";
import { RegisterModel } from "./../../../models/registerModel";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-register-form",
  templateUrl: "./register-form.component.html",
  styleUrls: ["./register-form.component.css"]
})
export class RegisterFormComponent implements OnInit {
  private registerFormModel: RegisterModel;
  private registerForm: FormGroup;

  constructor(private fb: FormBuilder) {}

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
}
