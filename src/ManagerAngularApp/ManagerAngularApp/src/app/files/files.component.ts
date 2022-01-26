import { Component, OnInit } from '@angular/core';
import { FileDto } from './file.dto';
import { FileService } from '../services/files.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})

export class FilesComponent implements OnInit {
  public files: FileDto[];
  public oldFiles: FileDto[];
  public oldFilesNum: number;
  public newFilesNum: number;

  constructor(private fileService: FileService, private toastr: ToastrService) {
    this.files = [];
    this.newFilesNum = 0;
    this.oldFilesNum = 0;
    this.oldFiles = [];
   }

  ngOnInit(): void {
    
    this.initFiles();
  }

  public initFiles(): void {
    this.oldFilesNum = this.newFilesNum;
    this.oldFiles = this.files;
    this.files = [];
    this.fileService.GetAllFiles().subscribe((data: any) =>{
      for(const f of (data as any)){
        this.files.push({
          "Name": f.name,
          "Downloaded": f.downloaded,
          "isNew": false
        });
      }
    },
    error => {
      if(error.error)
        this.toastr.error(error.error, 'Sorry');
      else
        this.toastr.error(error, 'Sorry');
    });
    this.newFilesNum = this.files.length;
    if (this.newFilesNum > this.oldFilesNum){
      for (let f of this.files){
        let found = false;
        for (let of of this.oldFiles) {
          if (of.Name == f.Name){
            found = true;
            break;
          }
        }
        if(!found){
          f.isNew = true;
        }
      }
    }
  }

  public downloadFile(filename: string): void{
    this.fileService.DownloadFile(filename).subscribe((data: any) =>{
      if (data){
        this.initFiles();
        //this.toastr.info('File has been downloaded successfully ! Now you can open it.', 'New file alert');
        alert('File has been downloaded successfully ! Now you can open it.');
      }
      if (!data) {
        this.initFiles();
        this.toastr.error('Rebex server is down. Please, try again later.', 'Sorry');
      }
  },
  error => {
    if(error.error)
      this.toastr.error(error.error, 'Sorry');
    else
      this.toastr.error(error, 'Sorry');
  });

}

public openFile(filename: string): void{
  this.fileService.OpenFile(filename);
  }
}

