import { ArticleData } from "./../data/data";
import { Article } from "./../models/article.model";
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  articles: Article[];
  constructor() { }

  ngOnInit() {
    this.articles = new ArticleData().getData();
  }
}
