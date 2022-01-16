import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicioLocalStorage } from '../../Servicios/servicio-local-storage.service';

@Component({
  selector: 'app-head',
  templateUrl: './head.component.html',
  styleUrls: ['./head.component.css']
})
export class HeadComponent implements OnInit {

  constructor(private router: Router, private ServicioLocalStorage: ServicioLocalStorage) { }

  ngOnInit(): void {
  }

  LogOut() {
    this.ServicioLocalStorage.RemoviendoCredencialesLocalStorage();
    this.router.navigate(['login']);
  }

}
