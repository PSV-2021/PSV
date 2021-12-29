import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TenderService } from '../services/tender.service';

@Component({
  selector: 'app-tender-offers',
  templateUrl: './tender-offers.component.html',
  styleUrls: ['./tender-offers.component.css']
})
export class TenderOffersComponent implements OnInit {
  public id = 0;
  public offers = [] as any[];

  constructor(private route:ActivatedRoute, private tenderService: TenderService) {
    this.id = 0;
    this.offers = [] as any[];
   }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.tenderService.GetAllOffersForTender(this.id).subscribe((data: any) => {
      console.log(data)
      this.offers = data;
    });
  }

}
