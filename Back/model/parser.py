class ParserDoc:
    """
    This class is designed for parsing .md files .
    Use of other formats is not recommended
    """

    def __enter__(self):
        raise NotImplementedError

    def __exit__(self, exc_type, exc_val, exc_tb):
        raise NotImplementedError


class Document:

    def __init__(self):
        raise NotImplementedError

    def get_word_weight(self):
        raise NotImplementedError

    def add_doc_to_database(self):
        raise NotImplementedError

    def delete_document_in_database(self):
        raise NotImplementedError
