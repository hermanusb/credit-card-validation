

class CardProviderDeleteForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ID: this.props.ID,
            Description: this.props.Description,
            ValidationRegex: this.props.ValidationRegex
        };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(e) {
        e.preventDefault();

        var antiForgeryToken = $("input[name=__RequestVerificationToken]").val();

        const data = new FormData();
        data.append('ID', this.state.ID);
        data.append('__RequestVerificationToken', antiForgeryToken);

        const xhr = new XMLHttpRequest();
        xhr.open('post', '/CardProvider/Delete/' + this.state.ID, true);

        xhr.onload = function () {
            console.log(xhr.response);
            var resp = JSON.parse(xhr.response);
            console.log(resp);
            window.location.href = resp.redirectToUrl;
        };
        xhr.onerror = function () {
            console.log(xhr.response);
        };

        xhr.send(data);
    }

    render() {
        return (
            <form method="post" onSubmit={this.handleSubmit}>
                <div className="form-horizontal">
                    <input type="hidden" id="ID" name="ID" value={this.state.ID} />

                    <div class="row">
                        <label className="col-md-2">Description</label>
                        <span className="col-md-2">{this.state.Description}</span>
                    </div>

                    <div class="row">
                        <label className="col-md-2">Validation Regex</label>
                        <span className="col-md-2">{this.state.ValidationRegex}</span>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <input type="submit" value="Delete" className="btn btn-danger" />
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}