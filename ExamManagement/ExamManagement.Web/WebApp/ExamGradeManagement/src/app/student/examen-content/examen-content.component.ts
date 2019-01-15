import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';


@Component({
  selector: 'app-examen-content',
  templateUrl: './examen-content.component.html',
  styleUrls: ['./examen-content.component.scss'],
  providers : [StudentService]
})
export class ExamenContentComponent implements OnInit {

  constructor(private studServ:StudentService) { }

  ngOnInit() {
    this.getAllExamsForStudent('JCPD2JFUEOJF2KFJ9');
  }

  async getAllExamsForStudent(userId:string) {
    console.log("a intrat");
    var result = await this.studServ.getAllStudentExams(userId);
    console.log(result);
    
  }

}
