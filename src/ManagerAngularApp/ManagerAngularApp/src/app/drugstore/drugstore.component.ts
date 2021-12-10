import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { DrugstoreWithImageDto } from '../all-drugstores/drugstore.with.image';
import { PharmacyService } from '../services/pharmacy.service';


@Component({
  selector: 'app-drugstore',
  templateUrl: './drugstore.component.html',
  styleUrls: ['./drugstore.component.css']
})
export class DrugstoreComponent implements OnInit {
  public id;
  public drugstore : DrugstoreWithImageDto;
  constructor(private route:ActivatedRoute, private pharmacyService: PharmacyService) {
    this.id = 0;
    this.drugstore = new DrugstoreWithImageDto();
   }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.pharmacyService.GetOneDrugstore(this.id).subscribe((data: any) =>{
      console.log(data);
      this.drugstore = {"Id": data.id,
                        "Name": data.name,
                        "Url": data.url,
                        "City": data.city,
                        "Address": data.address,
                        "Comment": data.comment,
                        "ImageBase64": data.base64Image
                      }
    });
  }

  editDrugstore(): void{
    this.pharmacyService.EditPharmacy(this.drugstore.Id, this.drugstore.ImageBase64, this.drugstore.Comment)
      .subscribe((data: any)=>{
        if (data)
          alert("Drugstore info updated succesfully!");
        else
          alert("Something went wrong!");
      });
  }

  handleFileSelect(evt: any){
    var files = evt.target.files;
    var file = files[0];

  if (files && file) {
      var reader = new FileReader();

      reader.onload =this._handleReaderLoaded.bind(this);

      reader.readAsBinaryString(file);
  }
}



_handleReaderLoaded(readerEvt: any) {
   var binaryString = readerEvt.target.result;
          this.drugstore.ImageBase64= "data:image/jpeg;base64," + btoa(binaryString);
          console.log(btoa(binaryString));
  }

}
