import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LinqChallengeService {

  constructor(private http: HttpClient, @Inject('BUSINESS_API_URL') private apiUrl: string) { }

  getChallenge(name: string): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this.apiUrl + "/linqchallenge/" + name)
      .subscribe(result => resolve(result) ,error=>{window.console.log(error)}
        );
    });
  }
}
