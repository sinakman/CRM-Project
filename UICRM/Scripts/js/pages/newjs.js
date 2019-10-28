@Component({
    selector: 'my-app',
    template: `
        <div class="example-config">
            <p>{{ mask }}</p>
            <ul>
                <li>Y - cyrillic only</li>
                <li>L - latin only</li>
            </ul>
        </div>
        <kendo-maskedtextbox
          [value]="value"
          [mask]="mask"
          [rules]="rules">
        </kendo-maskedtextbox>
    `
})

class AppComponent {
    public value: string = "абвг abcd";
    public mask: string = "YYYY LLLL";
    public rules: { [key: string]: RegExp } = {
        "L": /[a-zA-Z]/,
        "Y": /[\u0400-\u0481\u048A-\u04FF]/
    };
}