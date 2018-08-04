export class ListingFurnitureModel {
  constructor(
    public id: number,
    public make: string,
    public model: string,
    public year: number,
    public description: string,
    public price: number,
    public image: string
  ) {}
}
