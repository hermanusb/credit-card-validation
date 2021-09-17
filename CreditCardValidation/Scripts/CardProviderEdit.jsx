
class CardProviderContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <CardProviderEditForm
                    data={this.props.data}
                    url={this.props.url}
                />
            </div>
        );
    }
}

class CardProviderEditForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ID: this.props.data.ID,
            CreatedDate: this.props.data.CreatedDate,
            Description: this.props.data.Description,
            ValidationRegex: this.props.data.ValidationRegex,

            DescriptionValidation: '',
            ValidationRegexValidation: ''
        };

        this.handleDescriptionChange = this.handleDescriptionChange.bind(this);
        this.handleValidationRegexChange = this.handleValidationRegexChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleDescriptionChange(e) {
        if (!e.target.value) {
            this.setState({ DescriptionValidation: 'Description required' });
        } else {
            this.setState({ DescriptionValidation: ''});
        }

        this.setState({ Description: e.target.value });
    }

    handleValidationRegexChange(e) {
        if (!e.target.value) {
            this.setState({ ValidationRegexValidation: 'Validation Regex required' });
        } else {
            this.setState({ ValidationRegexValidation: '' });
        }

        this.setState({ ValidationRegex: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        const Description = this.state.Description.trim();
        const ValidationRegex = this.state.ValidationRegex.trim();

        if (!Description || !ValidationRegex) {
            return;
        }

        var antiForgeryToken = $("input[name=__RequestVerificationToken]").val();

        const data = new FormData();
        data.append('Description', Description);
        data.append('ValidationRegex', ValidationRegex);
        data.append('ID', this.state.ID);
        data.append('CreatedDate', this.state.CreatedDate);
        data.append('__RequestVerificationToken', antiForgeryToken);

        const xhr = new XMLHttpRequest();
        xhr.open('post', '/CardProvider/Edit/', true);

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
            <form action="" method="post" onSubmit={this.handleSubmit}>
                <div className="form-horizontal">
                    <input type="hidden" id="ID" name="ID" value={this.state.ID} />
                    <input type="hidden" id="CreatedDate" name="CreatedDate" value={this.state.CreatedDate} />

                    <div className="form-group">
                        <label className="control-label col-md-2">Description</label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                id="Description"
                                name="Description"
                                type="text"
                                placeholder="Enter Description"
                                value={this.state.Description}
                                onChange={this.handleDescriptionChange}
                            />
                            <span id="DescriptionValidation" className="text-danger">
                                {this.state.DescriptionValidation}
                            </span>
                        </div>
                    </div>

                    <div className="form-group">
                        <label className="control-label col-md-2">Validation Regex</label>
                        <div className="col-md-10">
                            <input
                                className="form-control"
                                id="ValidationRegex"
                                name="ValidationRegex"
                                type="text"
                                placeholder="Enter Validation Regex"
                                value={this.state.ValidationRegex}
                                onChange={this.handleValidationRegexChange}
                            />
                            <span id="ValidationRegexValidation" className="text-danger">
                                {this.state.ValidationRegexValidation}
                            </span>
                        </div>
                    </div>

                    <div className="form-group">
                        <div className="col-md-offset-2 col-md-10">
                            <input type="submit" value="Save" className="btn btn-success" />
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}