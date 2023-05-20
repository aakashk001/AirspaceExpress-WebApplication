import {Directive,ElementRef, HostListener, Input, Renderer2} from '@angular/core'


@Directive({
    selector: '[appButton]'
})
export class ButtonDirective {
    constructor(private ef:ElementRef, private red:Renderer2)
    {
       
    }
    @Input () appButton ="";

    @HostListener("mouseenter") onMouseEnter() {
        this.serachbutton(this.appButton)
      }

      @HostListener("mouseleave") onMouseLeave() {
        this.serachbutton("");
      }

    private serachbutton(color:string): void{
       this.ef.nativeElement.style.backgroundColor = color;
        this.ef.nativeElement.style.color = 'rgb(240, 40, 20)';
        this.ef.nativeElement.style.fontFamily = 'Verdana, Geneva, Tahoma, sans-serif';
        this.ef.nativeElement.style.fontSize = 'larger';
        this.ef.nativeElement.style.borderRadius = '25px';
        this.ef.nativeElement.style.padding = '6px 40px 6px 40px'
    }
}