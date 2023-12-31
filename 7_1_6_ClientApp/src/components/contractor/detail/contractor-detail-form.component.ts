import { Component } from '@angular/core';
import { ContractorService } from 'src/components/contractor/model/contractor.service';
import { NgForm } from '@angular/forms'

@Component({
  selector: 'contractor-detail-form',
  templateUrl: './contractor-detail-form.component.html',
  styles: [
  ]
})

export class ContractorDetailComponent {

  constructor(public contractorService: ContractorService) { }

  onSubmit(form: NgForm) {
    if (form.valid) {
      if (this.contractorService.theContractor.id.length == 0) {
        this.onInsertRecord(form);
      } else {
        this.onUpdateRecord(form);
      }
    }
  }

  onInsertRecord(form: NgForm) {
    this.contractorService.post()
    .subscribe({
      next: res => {
        console.log(res);
        //TODO: refactoring - list should not be refreshed, it should be updated
        this.contractorService.refreshList();
        this.contractorService.resetForm(form);
      },
      error: err => {
        console.log(err);
      }
    })    
  }

  onUpdateRecord(form: NgForm) {
    this.contractorService.put()
    .subscribe({
      next: res => {
        console.log(res);
        //TODO: refactoring - list should not be refreshed, it should be updated
        this.contractorService.refreshList();
        this.contractorService.resetForm(form);
      },
      error: err => {
        console.log(err);
      }
    })   
  }
}
