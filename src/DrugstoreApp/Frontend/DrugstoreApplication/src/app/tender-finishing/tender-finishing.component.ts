import { Component, OnInit } from '@angular/core';
import { TenderService } from '../services/tender.service';
import { TenderOfferDto } from '../tenders/tender.offer.dto';
import { WholeTenderDto } from '../tenders/whole.tender.dto';
import { FinishedTenderOfferDto } from './fisnished-tender-offer.dto';

@Component({
  selector: 'app-tender-finishing',
  templateUrl: './tender-finishing.component.html',
  styleUrls: ['./tender-finishing.component.css']
})
export class TenderFinishingComponent implements OnInit {

  public tenders: FinishedTenderOfferDto[];
  public tenderOffer: TenderOfferDto;

  constructor(private tendersService: TenderService) { 
    this.tenders = [];
    this.tenderOffer = new TenderOfferDto;
  }
  

  ngOnInit(): void {
    this.tendersService.GetAllFinishedTenders().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.tenders.push({
          "id": d.id,
          "tenderEnd": d.tenderEnd,
          "tenderInfo": d.tenderInfo,
          "counterOfferInfo": [],
          "isWinner" : d.isWinner
        });
      }
      for (const t of this.tenders){
        t.counterOfferInfo = JSON.parse(JSON.stringify(t.tenderInfo));
      }
    });
  }
  reloadPage() {
    window.location.reload();
  }
  async finishTender(offer : FinishedTenderOfferDto ):Promise<void> {

    await this.tendersService.GetAvailabilityForFinish(offer).subscribe((d:any) => {
      if(d){
        alert("Drugs available.");
        this.tendersService.FinishTender(offer).subscribe();
        alert("Tender finished." );
      }
      else{
        alert("Drugs not available.")
      }
    });
    
    this.reloadPage();
     

  }

}
