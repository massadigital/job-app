import { Component, OnInit } from '@angular/core';
import { LinqChallengeService } from 'src/app/services/linq-challenge.service';

@Component({
  selector: 'app-linq-challenge',
  templateUrl: './linq-challenge.component.html',
  styleUrls: ['./linq-challenge.component.scss']
})
export class LinqChallengeComponent implements OnInit {
  public tabs: any[] = [
    { title: 'Tarefa 1', name: 'CollatzTopRanked', data: '' },
    { title: 'Tarefa 2', name: 'EvenOddSplit', data: '' },
    { title: 'Tarefa 3', name: 'NotContainsFilter', data: '' },
  ];
  tabData: string[] = [];
  constructor(private linqChallengeService: LinqChallengeService) { }
  public selectedTabChange(event) {
    this.loadTabData(event.index);
  }
  loadTabData(tabIndex: number) {
    if (this.tabs[tabIndex].data) {
      return;
    }
    this.linqChallengeService.getChallenge(this.tabs[tabIndex].name).then(result => this.tabs[tabIndex].data = result.Message.replace(/\r\n/g, "<br />"));

  }
  ngOnInit() {
    this.loadTabData(0);
  }

}
