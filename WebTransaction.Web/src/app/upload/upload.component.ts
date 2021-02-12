import { Component, OnInit } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  public selectedFile: File = new File([], '');
  public uploadForm: FormGroup = new FormGroup({
    File: new FormControl(null)
  });

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  onSelectFile(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0];
  }

  onSubmit(data: any) {
  
    const formData = new FormData();
    formData.append('File', this.selectedFile);
  
    this.http.post('https://localhost:44319/api/Home/upload', formData)
    .subscribe(res => {
      alert('Uploaded!!');
    });
  }
}
