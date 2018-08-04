import { FurnitureService } from "./../furniture.service";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ListingFurnitureModel } from "../../models/listingFurnitureModel";

@Component({
  selector: "app-furniture-details",
  templateUrl: "./furniture-details.component.html",
  styleUrls: ["./furniture-details.component.css"]
})
export class FurnitureDetailsComponent implements OnInit {
  private furnitureModel: ListingFurnitureModel;
  constructor(
    private furnitureService: FurnitureService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params["id"];
      this.furnitureService
        .getDetails(id)
        .subscribe((data: ListingFurnitureModel) => {
          this.furnitureModel = data;
        });
    });
  }
}
