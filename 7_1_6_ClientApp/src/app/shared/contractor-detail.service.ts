import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { ContractorDetail } from './contractor-detail.model';


@Injectable({
  providedIn: 'root'
})
export class ContractorDetailService {

  url:string = environment.apiBaseUrl+'/Contractor'
  list: ContractorDetail[] = [];

  constructor(private http:HttpClient) { }

  refreshList() {
    this.http.get(this.url)
    .subscribe({
      next: res => {
        this.list = res as ContractorDetail[]
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
