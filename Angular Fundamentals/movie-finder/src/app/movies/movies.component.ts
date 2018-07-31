import { MoviesService } from "./../service/movies.service";
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  private popular: any;
  private theaters: any;
  private kidsPopular: any;
  private bestDrama: any;
  private searchResults: any;
  constructor(private moviesService: MoviesService) { }

  search(searchQuery) {
    const searchTerm = searchQuery.search;
    if (searchTerm) {
      this.moviesService.findAMovide(searchTerm).subscribe(data => {
        this.searchResults = data;
        console.log(this.searchResults);
      });
    }
  }

  ngOnInit() {
    this.moviesService.getPopular().subscribe(data => {
      this.popular = data;
      console.log(this.popular);
    });
    this.moviesService.getTheaters().subscribe(data => {
      this.theaters = data;
      console.log(this.theaters);
    });
    this.moviesService.getKidsPopular().subscribe(data => {
      this.kidsPopular = data;
      console.log(this.kidsPopular);
    });
    this.moviesService.getBestDrama().subscribe(data => {
      this.bestDrama = data;
      console.log(this.bestDrama);
    });
  }

}
