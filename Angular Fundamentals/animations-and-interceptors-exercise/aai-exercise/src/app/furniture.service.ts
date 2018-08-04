import { FurnitureModel } from "./../models/createFurnitureModel";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class FurnitureService {
  constructor(private http: HttpClient, private router: Router) {}

  createFurniture(data: FurnitureModel) {
    return this.http.post("http://localhost:5000/furniture/create", data);
  }

  getAllFurnitures() {
    return this.http.get("http://localhost:5000/furniture/all");
  }

  getDetails(id: number) {
    return this.http.get(`http://localhost:5000/furniture/details/${id}`);
  }

  getUserFurniture() {
    return this.http.get("http://localhost:5000/furniture/mine");
  }

  deleteFurniture(id: number) {
    return this.http.delete("http://localhost:5000/furniture/delete/${id}");
  }
}
