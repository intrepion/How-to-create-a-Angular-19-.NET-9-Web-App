import { Component, inject } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {CdkDragDrop, CdkDropList, CdkDrag, moveItemInArray} from '@angular/cdk/drag-drop';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-mainpage',
  imports: [MaterialModule],
  templateUrl: './mainpage.component.html',
  styleUrl: './mainpage.component.css'
})
export class MainpageComponent {
  private _snackBar = inject(MatSnackBar);
  // this._snackBar.open(message, action);

  lstData: any = []

  constructor(private service: ServiceService) {
  }

  ngOnInit() {
    this.getAllPokemonData()
  }

  getAllPokemonData() {
    this.service.getAllPokemonData().subscribe({
      next: (res: any) => {
        console.log('pokemonObj', res)
        this.lstData = res
      },
      error: (error: any) => {
        console.log(error)
      }
    })
  }

  drop(event: CdkDragDrop<{name: string}[]>) {
    moveItemInArray(this.lstData, event.previousIndex, event.currentIndex);
  }
}
