import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private Router: Router) {

  }

  @Output() ocultarMenu = new EventEmitter<boolean>();
  @Input() ocultarTexto: boolean = false;

  ngOnInit(): void {
   
  }

  AbrirMenu() {
    this.ocultarMenu.emit(false);
  }
  
}
