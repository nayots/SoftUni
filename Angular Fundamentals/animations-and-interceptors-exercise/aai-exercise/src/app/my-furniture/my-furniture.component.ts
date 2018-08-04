import { ActivatedRoute, Router } from "@angular/router";
import { FurnitureService } from "./../furniture.service";
import { Component, OnInit } from "@angular/core";
import { ListingFurnitureModel } from "../../models/listingFurnitureModel";

@Component({
  selector: "app-my-furniture",
  templateUrl: "./my-furniture.component.html",
  styleUrls: ["./my-furniture.component.css"]
})
export class MyFurnitureComponent implements OnInit {
  private userFurnitures: ListingFurnitureModel[];
  constructor(
    private furnitureService: FurnitureService,
    private router: Router
  ) {}

  ngOnInit() {
    this.furnitureService
      .getUserFurniture()
      .subscribe((data: ListingFurnitureModel[]) => {
        this.userFurnitures = data;
        console.log(this.userFurnitures);
      });
  }

  onDelete(id: any) {
    console.log(id);
    this.furnitureService.deleteFurniture(id).subscribe(res => {
      console.log(res);
      this.router.navigate(["/furniture/my"]);
    });
  }
}
