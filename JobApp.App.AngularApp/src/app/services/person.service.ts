import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataQuery, DataResult, Pagination } from '../models/common.models';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient, @Inject('BUSINESS_API_URL') private apiUrl: string) { }
  listPersons(): Promise<DataResult<any>> {
    return new Promise<DataResult<any>>((resolve, reject) => {
      const queryParams = { page: "1", pageSize: "10", sort: "Id", sortDirection:"1", filterData: "" };
      this.http.get<any[]>(this.apiUrl + "/person/list", { params: queryParams }).subscribe(result => {
        const pagination: Pagination = { ItemCount: 0, PageCount: 0, PageNumber: 0, PageSize: 0 };
        let resultModel: DataResult<any> = {
          FilterExpressions: [],
          SortExpressions: [],
          Pagination: pagination,
          Items: result
        };
        resolve(resultModel);
      });
    });
  }
  /*getChallenge(name: string): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this.apiUrl + "/linqchallenge/" + name)
      .subscribe(result => resolve(result) ,error=>{window.console.log(error)}
        );
    });
  }*/
}
