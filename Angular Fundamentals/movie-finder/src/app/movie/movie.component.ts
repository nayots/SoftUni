import { MoviesService } from "./../service/movies.service";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-movie",
  templateUrl: "./movie.component.html",
  styleUrls: ["./movie.component.css"]
})
export class MovieComponent implements OnInit {
  private movie: any;
  constructor(
    private movieService: MoviesService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const id = params["id"];
      this.movieService.getMovie(id).subscribe(movie => {
        this.movie = movie;
      });
    });
  }
}
