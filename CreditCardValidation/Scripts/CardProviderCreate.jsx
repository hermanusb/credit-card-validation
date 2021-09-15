﻿



class CardProviderCreateForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Description: '',
            ValidationRegex: '',

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
            this.setState({ DescriptionValidation: '' });
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

        if (!Description) {
            this.setState({ DescriptionValidation: 'Description required' });   
            return;
        }

        if (!ValidationRegex) {
            this.setState({ ValidationRegexValidation: 'Validation Regex required' });
            return;
        }

        var antiForgeryToken = $("input[name=__RequestVerificationToken]").val();

        const data = new FormData();
        data.append('Description', Description);
        data.append('ValidationRegex', ValidationRegex);
        data.append('__RequestVerificationToken', antiForgeryToken);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.url, true);

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
                            <input type="submit" value="Save" className="btn btn-default" />
                        </div>
                    </div>
                </div>
            </form>
        );
    }
}