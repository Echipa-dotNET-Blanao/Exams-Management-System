import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeContentComponent } from './home-content/home-content.component';
import { ExamenContentComponent } from './examen-content/examen-content.component';
import { IstoricExamenContentComponent } from './istoric-examen-content/istoric-examen-content.component';
import { ContestatiiContentComponent } from './contestatii-content/contestatii-content.component';

@NgModule({
  declarations: [ HomeContentComponent, ExamenContentComponent, IstoricExamenContentComponent, ContestatiiContentComponent],
  imports: [
    CommonModule
  ],
  exports: [
  ]
})
export class StudentModule { }
