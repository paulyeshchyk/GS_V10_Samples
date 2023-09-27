import { Component, OnInit } from '@angular/core';
import { ContractorService } from 'src/app/contractor/service/contractor.service';
import { ContractorDTO } from '../model/contractor.model';

@Component({
  selector: 'app-contractor-list',
  templateUrl: './contractor-list.component.html',
  styles: []
})

export class ContractorListComponent implements OnInit {

  constructor(public contractorService: ContractorService) {

  }

  ngOnInit(): void {
    this.contractorService.refreshList();
  }

  onDelete(id:string) {
    this.contractorService
    .delete(id)
    .subscribe({
        next: res => {
          this.contractorService.refreshList();
          console.log(res);
        },
        error: err => {
          console.log(err);
        }
    })
  }

  populateForm(contractor: ContractorDTO) {
    console.log(contractor.id);
    this.contractorService.theContractor = contractor;
  }
}
