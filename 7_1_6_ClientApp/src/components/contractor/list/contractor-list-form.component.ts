import { Component, OnInit } from '@angular/core';
import { ContractorService } from 'src/components/contractor/model/contractor.service';
import { ContractorDTO } from 'src/components/contractor/model/contractor.model';

@Component({
  selector: 'contractor-list-form',
  templateUrl: './contractor-list-form.component.html',
  styles: []
})

export class ContractorListComponent implements OnInit {

  constructor(public contractorService: ContractorService) { }

  ngOnInit(): void {
    this.contractorService.refreshList();
  }

  onContractorItemDelete(id: string) {
    this.contractorService.delete(id)
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

  onContractorItemClick(contractor: ContractorDTO) {
    console.log(contractor.id);
    this.contractorService.theContractor = contractor;
  }
  
}
