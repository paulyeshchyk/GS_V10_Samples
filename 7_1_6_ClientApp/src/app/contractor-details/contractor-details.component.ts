import { Component, OnInit } from '@angular/core';
import { ContractorDetailService } from '../shared/contractor-detail.service';

@Component({
  selector: 'app-contractor-details',
  templateUrl: './contractor-details.component.html',
  styles: [
  ]
})
export class ContractorDetailsComponent implements OnInit {

  constructor(public service: ContractorDetailService) {

  }

  ngOnInit(): void {
    this.service.refreshList();
  }
}
