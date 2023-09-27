import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { ContractorDTO, ContractorDTO_Post } from 'src/app/contractor/model/contractor.model';
import { NgForm } from '@angular/forms'


@Injectable({
  providedIn: 'root'
})

export class ContractorService {

  url: string = environment.apiBaseUrl + '/Contractor'
  theContractorList: ContractorDTO[] = [];
  theContractor: ContractorDTO = new ContractorDTO();

  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.theContractorList = res as ContractorDTO[]
        },
        error: err => {
          console.log(err)
        }
      })
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.theContractor = new ContractorDTO();
  }

  post() {
    let postData = new ContractorDTO_Post();
    postData.address = this.theContractor.address;
    postData.name = this.theContractor.name;

    return this.http.post(this.url, postData)
  }

  put() {
    return this.http.put(this.url + '/' + this.theContractor.id, this.theContractor)
  }

  delete(guid: string) {
    return this.http.delete(this.url + '/' + guid);
  }
}
