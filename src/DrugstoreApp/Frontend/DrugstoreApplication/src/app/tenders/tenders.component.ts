import { Component, OnInit } from '@angular/core';
import { TenderDto } from './tender.dto';
import { WholeTenderDto } from './whole.tender.dto';
import { TenderService } from '../services/tender.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {

  public tenders: WholeTenderDto[];
  public tenderInfo: TenderDto[];
  public response: string;
  constructor(private tendersService: TenderService) { 
    this.tenders = [];
    this.response = "";
    this.tenderInfo = [];
  }

  /*
    respond(tender : TenderDto): void {
    console.log(this.response);
    this.tendersService.SendResponse(tender).subscribe((d: any) =>{alert("NAJJACI" + d.response)});
  }
  */
  ngOnInit(): void {
    // this.tendersService.GetAllActiveTenders().subscribe((data: any) => {
    //   for (const d of (data as any)) {
    //     this.tenders.push({
    //       "id": d.id,
    //       "tenderEnd": d.tenderEnd,
    //       "tenderInfo": d.tenderInfo
    //     });
    //   }
    // });
    this.tenders.push({
      "id": 1111,
      "tenderEnd": new Date(),
      "tenderInfo": [{"drugName" : "Lek1", "amount" : 4 }, {"drugName" : "Lek2", "amount" : 5 } ]
    });
  }

}
