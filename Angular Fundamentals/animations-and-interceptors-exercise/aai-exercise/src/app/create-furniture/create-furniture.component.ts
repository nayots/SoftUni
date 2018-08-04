import { Router } from "@angular/router";
import { FurnitureService } from "./../furniture.service";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { FurnitureModel } from "../../models/createFurnitureModel";

@Component({
  selector: "app-create-furniture",
  templateUrl: "./create-furniture.component.html",
  styleUrls: ["./create-furniture.component.css"]
})
export class CreateFurnitureComponent implements OnInit {
  private createForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private furnitureService: FurnitureService,
    private router: Router
  ) {}

  ngOnInit() {
    this.createForm = this.fb.group({
      make: ["", [Validators.minLength(4), Validators.required]],
      model: ["", [Validators.minLength(4), Validators.required]],
      year: ["", [Validators.min(1950), Validators.max(2050)]],
      description: ["", [Validators.minLength(11)]],
      price: ["", [Validators.min(1)]],
      imageUrl: ["", [Validators.required]],
      material: [""]
    });
  }

  private onSubmit() {
    console.log(this.createForm);
    this.furnitureService
      .createFurniture(
        new FurnitureModel(
          this.make.value,
          this.model.value,
          this.year.value,
          this.description.value,
          this.price.value,
          this.imageUrl.value,
          this.material.value
        )
      )
      .subscribe(data => {
        this.router.navigate(["/furniture/all"]);
      });
  }

  get make() {
    return this.createForm.get("make");
  }

  get model() {
    return this.createForm.get("model");
  }

  get year() {
    return this.createForm.get("year");
  }
  get description() {
    return this.createForm.get("description");
  }
  get price() {
    return this.createForm.get("price");
  }
  get imageUrl() {
    return this.createForm.get("imageUrl");
  }
  get material() {
    return this.createForm.get("material");
  }
}
