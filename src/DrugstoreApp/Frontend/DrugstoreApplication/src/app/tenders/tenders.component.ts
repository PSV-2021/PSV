import { Component, OnInit } from '@angular/core';
import { TenderDto } from './tender.dto';
import { WholeTenderDto } from './whole.tender.dto';
import { TenderService } from '../services/tender.service';
import { Router } from '@angular/router';
import { TenderOfferDto } from './tender.offer.dto';



@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {

  public tenders: WholeTenderDto[];
  public tenderOffer: TenderOfferDto;

  constructor(private tendersService: TenderService) { 
    this.tenders = [];
    this.tenderOffer = new TenderOfferDto;
  }

  
  addOffer(tender : WholeTenderDto, price : string): void {
    this.tenderOffer = new TenderOfferDto;
    this.tenderOffer.price = parseFloat(price);
    this.tenderOffer.tender = tender;
    alert("tender to be offered: " + this.tenderOffer.tender.tenderInfo.map(a => (a.drugName + " " + a.amount)).toString());
    this.tendersService.AddOffer(this.tenderOffer).subscribe((d: any) =>{alert("NAJJACI" + d.response)});
  }

  addCounterOffer(tender : WholeTenderDto, price : string): void {
    this.tenderOffer = new TenderOfferDto;
    this.tenderOffer.price = parseFloat(price);
    this.tenderOffer.tender = tender;
    alert("tender to be offered: " + this.tenderOffer.tender.counterOfferInfo.map(a => (a.drugName + " " + a.amount)).toString());
    this.tendersService.AddCounterOffer(this.tenderOffer).subscribe((d: any) =>{alert("NAJJACI" + d.response)});
  }
  
  ngOnInit(): void {
    this.tendersService.GetAllActiveTenders().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.tenders.push({
          "id": d.id,
          "tenderEnd": d.tenderEnd,
          "tenderInfo": d.tenderInfo,
          "counterOfferInfo": []
        });
      }
      for (const t of this.tenders){
        t.counterOfferInfo = JSON.parse(JSON.stringify(t.tenderInfo));
      }
    });
    // this.tenders.push({
    //   "id": 1111,
    //   "tenderEnd": new Date(),
    //   "tenderInfo": [{"drugName" : "Lek1", "amount" : 4 }, {"drugName" : "Lek2", "amount" : 5 } ]
    // });
  }

}
