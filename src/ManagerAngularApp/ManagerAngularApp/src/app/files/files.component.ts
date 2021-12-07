import { Component, OnInit } from '@angular/core';
import { FileDto } from './file.dto';
import { FileService } from '../services/files.service';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})

export class FilesComponent implements OnInit {
  public files: FileDto[];
  public newFiles: FileDto[];

  constructor(private fileService: FileService) {
    this.files = [];
    this.newFiles = [];
   }

  ngOnInit(): void {
    this.fileService.GetAllFiles().subscribe((data: any) =>{
      console.log(data);
      for(const f of (data as any)){
        this.files.push({
          "Name": f.name,
          "Downloaded": f.downloaded
        });
      }
    });
  }

  public downloadFile(filename: string): void{
    this.files = [];
    this.fileService.DownloadFile(filename).subscribe((data: any) =>{
      console.log(data);
      for(const f of (data as any)){
        this.files.push({
          "Name": f.name,
          "Downloaded": f.downloaded
        });
      }
    });
    alert('File has been downloaded successfully ! Now you can open it.');
  }

public openFile(filename: string): void{
  this.fileService.OpenFile(filename);
  }
}

