import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TenderService } from '../services/tender.service';
import { TenderOfferDto } from './tender-offer.dto';
import { ToastrService } from 'ngx-toastr';
import { TenderOfferService } from '../services/tender-offer.service';

@Component({
  selector: 'app-tender-offers',
  templateUrl: './tender-offers.component.html',
  styleUrls: ['./tender-offers.component.css']
})
export class TenderOffersComponent implements OnInit {
  public id = "";
  public offers = [] as any[];


  constructor(private tenderOfferService: TenderOfferService,private route:ActivatedRoute, private tenderService: TenderService,private toastr: ToastrService) {
    this.id = "";
    this.offers = [] as any[];
   }


  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.tenderService.GetAllOffersForTender(this.id).subscribe((data: any) => {
      console.log(data)
      this.offers = data;
    });
  }
  completeTransaction(offer: TenderOfferDto):void{
      this.tenderOfferService.completeTransaction(offer).subscribe((d: any) =>{
        this.toastr.success('You have succesfuly ended the tender', 'Tender')
        }
      )};
}
