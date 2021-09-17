class CardProviderList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: this.props.initialData };
    }

    render() {
        return (
            <table className="table">
                <tr>
                    <th>Description</th>
                    <th>Created Date</th>
                    <th>Last modified</th>
                    <th>Validation Regex</th>
                    <th></th>
                </tr>

                {this.state.data.map((cp) => (
                    <tr>
                        <td>
                            {cp.Description}
                        </td>

                        <td>
                            {cp.CreatedDate}
                        </td>

                        <td>
                            {cp.Lastmodified}
                        </td>

                        <td>
                            {cp.ValidationRegex}
                        </td>

                        <td>
                            <a className="btn" href={'CardProvider/Edit/' + cp.ID}>Edit</a>
                            <a className="btn" href={'CardProvider/Delete/' + cp.ID}>Delete</a>
                        </td>
                    </tr>
                ))}
            </table>
        );
    }
}

