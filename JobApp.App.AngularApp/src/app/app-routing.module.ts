import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GithubUsersComponent } from './pages/github-users/github-users.component';
import { LinqChallengeComponent } from './pages/linq-challenge/linq-challenge.component';
import { PersonComponent } from './pages/person/person.component';


const routes: Routes = [
  { path: "github-users", component: GithubUsersComponent },
  { path: "primeira-atividade", component: LinqChallengeComponent },
  { path: "pessoas", component: PersonComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
