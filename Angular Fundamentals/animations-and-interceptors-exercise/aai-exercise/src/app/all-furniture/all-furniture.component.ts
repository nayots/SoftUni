import { ListingFurnitureModel } from "./../../models/listingFurnitureModel";
import { FurnitureService } from "./../furniture.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-all-furniture",
  templateUrl: "./all-furniture.component.html",
  styleUrls: ["./all-furniture.component.css"]
})
export class AllFurnitureComponent implements OnInit {
  constructor(private furnitureService: FurnitureService) {}
  furnitures: ListingFurnitureModel[];
  ngOnInit() {
    this.furnitureService
      .getAllFurnitures()
      .subscribe((data: ListingFurnitureModel[]) => {
        this.furnitures = data;
        console.log(this.furnitures);
      });
  }
}
