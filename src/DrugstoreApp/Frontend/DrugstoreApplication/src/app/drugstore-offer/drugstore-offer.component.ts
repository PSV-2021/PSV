import { Component, OnInit } from '@angular/core';
import { DrugStoreOfferService } from '../services/drugstore-offer.service';
import { DrugstoreOfferDto } from './drugstore-offer.dto';

@Component({
  selector: 'app-drugstore-offer',
  templateUrl: './drugstore-offer.component.html',
  styleUrls: ['./drugstore-offer.component.css']
})
export class DrugstoreOfferComponent implements OnInit {
  public drugstoreOffer: DrugstoreOfferDto;
  constructor(private drugStoreOfferService: DrugStoreOfferService) { 
    this.drugstoreOffer = new DrugstoreOfferDto;
  }
  sendOffer(drugstoreOffer : DrugstoreOfferDto): void {
    console.log(this.drugstoreOffer);
    this.drugStoreOfferService.SendOffer(drugstoreOffer).subscribe((d: any) =>{alert("NAJJACI" )});
  }
  

  ngOnInit(): void {
  }

}
