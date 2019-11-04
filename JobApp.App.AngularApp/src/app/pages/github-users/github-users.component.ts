import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { GithubApiService } from '../../services/github-api.service';
import { GitHubUser, GitHubUserDetails } from '../../models/github-user.model';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-github-users',
  templateUrl: './github-users.component.html',
  styleUrls: ['./github-users.component.scss']
})
export class GithubUsersComponent implements OnInit {
  @ViewChild("detailsView", { static: false }) secondDialog: TemplateRef<any>;

  public gitHubUsers: GitHubUser[];
  public gitHubUser: GitHubUserDetails;
  public pages: number[] = [0];
  public currentPage: number = 1;
  public displayedColumns: string[] = ['id', 'login', 'avatar_url'];
  public browsing: boolean = false;


  constructor(private apiService: GithubApiService, public dialog: MatDialog) { }
  viewDetails(login: string) {
    this.apiService.getUser(login).then(result => {
      this.gitHubUser = result;
      this.dialog.open(this.secondDialog,{width:'64vw'});
    });

  }
  browseData(pageNumber: number = 1) {
    if (this.browsing) {
      return;
    }
    this.browsing = true;
    pageNumber = Math.max(pageNumber, 1);
    const sinceParam = this.pages[pageNumber - 1];
    this.apiService.getUsers(sinceParam).then(result => {
      this.browsing = false;
      if (result.length === 0) {
        return;
      }
      this.currentPage = pageNumber;
      this.gitHubUsers = result;
      const newPageParam = this.gitHubUsers[this.gitHubUsers.length - 1].id;;
      if (this.pages.indexOf(newPageParam) === -1) {
        this.pages.push(newPageParam);
      }
    });
  }

  ngOnInit() {
    this.browseData();
  }

}
