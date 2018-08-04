export class FurnitureModel {
  constructor(
    private make: string,
    private model: string,
    private year: number,
    private description: string,
    private price: number,
    private image: string,
    private material: string
  ) {}
}
