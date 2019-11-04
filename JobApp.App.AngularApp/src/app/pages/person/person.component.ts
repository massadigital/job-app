import { Component, OnInit } from '@angular/core';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {
  public items: any[];
  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.personService.listPersons().then(result => this.items = result.Items);
  }

}
