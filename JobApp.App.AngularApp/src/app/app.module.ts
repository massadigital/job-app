import { BrowserModule } from '@angular/platform-browser';
import { NgModule, InjectionToken } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GithubUsersComponent } from './pages/github-users/github-users.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatTableModule,
  MatButtonModule,
  MatIconModule,
  MatSidenavModule,
  MatDialogModule,
  MatToolbarModule,
  MatListModule,
  MatGridListModule,
  MatCardModule,
  MatTabsModule,
  
} from '@angular/material';
import { GithubApiService } from './services/github-api.service'
import { HttpClientModule } from '@angular/common/http';
import { LinqChallengeComponent } from './pages/linq-challenge/linq-challenge.component';
import { PersonComponent } from './pages/person/person.component';

@NgModule({
  declarations: [
    AppComponent,
    GithubUsersComponent,
    LinqChallengeComponent,
    PersonComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatDialogModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatTabsModule,
  ],
  providers: [
    GithubApiService,
    {
      provide: 'GITHUB_API_URL',
      useValue: "https://api.github.com"
    },
    {
      provide: 'BUSINESS_API_URL',
      useValue: "http://localhost:58580/api"
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
