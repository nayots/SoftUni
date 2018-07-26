import { MoviesComponent } from "./movies/movies.component";
import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";
import { MovieComponent } from "./movie/movie.component";

const routes: Routes = [
    {path: "", component: MoviesComponent},
    {path: "movie/:id", component: MovieComponent}
];

const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);

export {AppRoutes};
